package com.spac.questionnaire.services;

import com.spac.questionnaire.dao.Role;
import com.spac.questionnaire.dao.User;
import com.spac.questionnaire.dto.AuthenticationResponse;
import com.spac.questionnaire.dto.LoginDto;
import com.spac.questionnaire.dto.RegisterDto;
import com.spac.questionnaire.repositories.UserRepository;
import com.spac.questionnaire.security.JwtService;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class AuthenticationService {

    @Autowired
    UserRepository userRepository;

    @Autowired
    PasswordEncoder passwordEncoder;

    @Autowired
    AuthenticationManager authenticationManager;

    @Autowired
    JwtService jwtService;
    public ResponseEntity<AuthenticationResponse> register(RegisterDto registerDto) {

        if(userRepository.existsByEmail(registerDto.getEmail())){
            throw new IllegalArgumentException("Username Is Already Taken!");
        }

        User user = User.builder()
                .firstName(registerDto.getFirstName())
                .lastName(registerDto.getLastName())
                .email(registerDto.getEmail())
                .password(passwordEncoder.encode(registerDto.getPassword()))
                .role(Role.USER)
                .build();

        userRepository.save(user);

        String jwtToken = jwtService.generateToken(user);

        AuthenticationResponse authenticationResponse = AuthenticationResponse.builder()
                .token(jwtToken)
                .build();

        return new ResponseEntity<>(authenticationResponse, HttpStatus.OK);
    }

    public ResponseEntity<AuthenticationResponse> login(LoginDto loginDto) {
        authenticationManager.authenticate(
                new UsernamePasswordAuthenticationToken(
                        loginDto.getEmail(),
                        loginDto.getPassword()
                )
        );

        User user = userRepository.findByEmail(loginDto.getEmail())
                .orElseThrow(()-> new UsernameNotFoundException("Username Not Found!"));

        String jwtToken = jwtService.generateToken(user);

        AuthenticationResponse authenticationResponse = AuthenticationResponse.builder()
                .token(jwtToken)
                .build();

        return new ResponseEntity<>(authenticationResponse, HttpStatus.OK);
    }
}

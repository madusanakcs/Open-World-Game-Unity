package com.spac.questionnaire.controllers;

import com.spac.questionnaire.dto.AuthenticationResponse;
import com.spac.questionnaire.dto.LoginDto;
import com.spac.questionnaire.dto.RegisterDto;
import com.spac.questionnaire.services.AuthenticationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("api/auth")
public class AuthenticationController {

    @Autowired
    AuthenticationService authenticationService;

    @PostMapping("/register")
    public ResponseEntity<AuthenticationResponse> register(@RequestBody RegisterDto registerDto){
        return authenticationService.register(registerDto);
    }

    @PostMapping("/login")
    public ResponseEntity<AuthenticationResponse> login(@RequestBody LoginDto loginDto){
        return authenticationService.login(loginDto);
    }

}

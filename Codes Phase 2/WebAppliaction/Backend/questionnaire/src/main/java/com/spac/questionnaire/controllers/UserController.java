package com.spac.questionnaire.controllers;

import com.spac.questionnaire.services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("user")
public class UserController {

    @Autowired
    UserService userService;

    @GetMapping("isQuizDone")
    public ResponseEntity<Boolean> isQuizDone(){
        return userService.isQuizDone();
    }

    @GetMapping("getScore")
    public ResponseEntity<Integer> getScore(){
        return userService.getScore();
    }
}

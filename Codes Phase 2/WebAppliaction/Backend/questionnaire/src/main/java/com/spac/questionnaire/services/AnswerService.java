package com.spac.questionnaire.services;

import com.spac.questionnaire.repositories.AnswerRepository;
import com.spac.questionnaire.dao.Answer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AnswerService {

    @Autowired
    AnswerRepository answerRepository;

    public ResponseEntity<List<Answer>> getAllAnswers() {
        return new ResponseEntity<>(answerRepository.findAll(), HttpStatus.OK);
    }
}

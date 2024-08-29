package com.spac.questionnaire.services;

import com.spac.questionnaire.repositories.AnswerRepository;
import com.spac.questionnaire.repositories.QuestionRepository;
import com.spac.questionnaire.dao.Question;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class QuestionService {

    @Autowired
    QuestionRepository questionRepository;

    public ResponseEntity<List<Question>> getAllQuestions() {
        return new ResponseEntity<>(questionRepository.findAll(), HttpStatus.OK);

    }

}

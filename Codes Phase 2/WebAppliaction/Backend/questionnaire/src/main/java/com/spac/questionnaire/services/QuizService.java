package com.spac.questionnaire.services;

import com.spac.questionnaire.dao.Answer;
import com.spac.questionnaire.dao.Question;
import com.spac.questionnaire.dao.QuizScore;
import com.spac.questionnaire.dao.User;
import com.spac.questionnaire.dto.*;
import com.spac.questionnaire.repositories.AnswerRepository;
import com.spac.questionnaire.repositories.QuestionRepository;
import com.spac.questionnaire.repositories.ScoreRepository;
import com.spac.questionnaire.repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class QuizService {

    @Autowired
    QuestionRepository questionRepository;

    @Autowired
    AnswerRepository answerRepository;

    @Autowired
    UserRepository userRepository;

    @Autowired
    ScoreRepository scoreRepository;

    public ResponseEntity<List<QuestionWrapper>> getQuiz() {
        List<QuestionWrapper> quiz = new ArrayList<>();
        List<Question> allQuestions = questionRepository.findAll();
        for(Question q: allQuestions ){
            List<AnswerWrapper> answerWrappers = new ArrayList<>();
            List<Answer> allAnswers = answerRepository.findByQuestionId(q.getId());
            for(Answer a: allAnswers){
                AnswerWrapper answerWrapper = new AnswerWrapper(a.getId(),a.getAnswerTitle());
                answerWrappers.add(answerWrapper);
            }

            QuestionWrapper questionWrapper = new QuestionWrapper(q.getId(),q.getQuestionTitle(),answerWrappers);
            quiz.add(questionWrapper);
        }

        return new ResponseEntity<>(quiz, HttpStatus.OK);


    }

    public ResponseEntity<FeedbackResult> generateFeedback(List<Response> responses) {
        String userEmail = SecurityContextHolder.getContext().getAuthentication().getName();

        List<Feedback> feedbackList = new ArrayList<>();
        int score = 0;
        for(Response r: responses){
            Optional<Question> questionOptional = questionRepository.findById(r.getQuestionId());
            Optional<Answer> answerOptional = answerRepository.findById(r.getAnswerId());
            Optional<Answer> correctAnswerOptional = answerRepository.findCorrectAnswerByQuestionId(r.getQuestionId());


            if (questionOptional.isPresent() && answerOptional.isPresent() && correctAnswerOptional.isPresent()){
                Question question = questionOptional.get();
                Answer answer = answerOptional.get();
                Answer correctAnswer = correctAnswerOptional.get();

                if(answer.isCorrect()){
                    score++;
                }

                Feedback feedback = new Feedback(r.getQuestionId(),correctAnswer.getId(),answer.getId(),question.getGeneralFeedback(),answer.getSpecificFeedback());

                feedbackList.add(feedback);

            }
        }

        Optional<User> optionalUser = userRepository.findByEmail(userEmail);

        if(optionalUser.isPresent()) {
            User user = optionalUser.get();

            user.setQuizDone(true);
            userRepository.save(user);

            QuizScore quizScore = new QuizScore();
            quizScore.setUser(user);
            quizScore.setScore(score);
            scoreRepository.save(quizScore);

        }


        FeedbackResult feedbackResult = new FeedbackResult(score,feedbackList);
        return new ResponseEntity<>(feedbackResult,HttpStatus.OK);
    }
}

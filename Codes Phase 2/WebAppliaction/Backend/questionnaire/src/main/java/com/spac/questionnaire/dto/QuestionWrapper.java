package com.spac.questionnaire.dto;


import com.spac.questionnaire.dto.AnswerWrapper;
import lombok.Data;

import java.util.List;

@Data
public class QuestionWrapper {
    private Integer questionId;
    private String question;
    private List<AnswerWrapper> answerWrappers;

    public QuestionWrapper(Integer questionId, String question, List<AnswerWrapper> answerWrappers) {
        this.questionId = questionId;
        this.question = question;
        this.answerWrappers = answerWrappers;
    }
}

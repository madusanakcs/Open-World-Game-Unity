package com.spac.questionnaire.dto;

import lombok.Data;
import lombok.RequiredArgsConstructor;

@Data
@RequiredArgsConstructor
public class Response {
    private Integer questionId;
    private Integer answerId;

}

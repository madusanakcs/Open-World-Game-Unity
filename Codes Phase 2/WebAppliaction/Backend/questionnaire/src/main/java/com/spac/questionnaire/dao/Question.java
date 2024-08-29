package com.spac.questionnaire.dao;

import com.fasterxml.jackson.annotation.JacksonAnnotation;
import jakarta.persistence.*;
import lombok.Data;

import java.util.List;

@Entity
@Data
@Table(name = "questions")
public class Question {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private String questionTitle;
    private String generalFeedback;

}

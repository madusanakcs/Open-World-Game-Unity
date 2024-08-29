package com.spac.questionnaire.repositories;

import com.spac.questionnaire.dao.Answer;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface AnswerRepository extends JpaRepository<Answer,Integer> {
    List<Answer> findByQuestionId(Integer id);

    @Query("SELECT a FROM Answer a WHERE a.question.id = :questionId AND a.isCorrect = true")
    Optional<Answer> findCorrectAnswerByQuestionId(@Param("questionId") Integer questionId);

}

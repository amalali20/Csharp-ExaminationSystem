# Examination System

## Project Overview

This project implements an **Examination System** in C# that supports multiple types of questions and exams. It is designed with an **object-oriented approach**, incorporating **inheritance, interfaces, generics, and event-driven programming**. 

## Features

- **Question Types:**
  - True/False
  - Multiple Choice (Single Answer)
  - Multiple Choice (Multiple Answers)
- **Question List Management**
  - Inherits from `List<Question>`
  - Overrides `Add()` method to log questions into a file
- **Answer List and Management**
- **Exam Base Class**
  - Attributes: Exam time, number of questions, answer dictionary, status (Starting, Queued, Finished)
  - Implements `IClonable`, `IComparable`
  - Overrides `ToString()`, `Equals()`, `GetHashCode()`
- **Exam Types:**
  - Practice Exam: Displays the correct answers after submission.
  - Final Exam: Displays only questions and answers.
- **Subject Association**
- **Event Notification System**
  - When an exam enters `Starting` mode, all registered students for that subject are notified.

## Class Structure

### 1. `Question` (Base Class)

Represents a general question structure with:

- `Header` (title of the question)
- `Body` (question text)
- `Marks` (assigned marks)
- `Answers` (linked to `AnswerList`)

### 2. Question Subclasses

- `TrueFalseQuestion`
- `ChooseOneQuestion`
- `ChooseAllQuestion`

### 3. `QuestionList<T>`

- Inherits from `List<T>`
- Overrides `Add()` to log questions to a file

### 4. `Answer` Class

Represents an answer with its correctness status.

### 5. `AnswerList`

Stores multiple answers related to a question.

### 6. `Exam` (Base Class)

- Attributes: `Time`, `Number of Questions`, `Question-Answer Dictionary`
- Methods:
  - `ShowExam()` (overridden in subclasses)
  - Implements `IClonable`, `IComparable`
  - Supports `ToString()`, `Equals()`, `GetHashCode()`

### 7. `PracticeExam` (Derived from `Exam`)

- Displays correct answers after the test is completed.
- Reads questions dynamically from `Questions.txt`
- Logs results to `PracticeExam_1.txt`

### 8. `FinalExam` (Derived from `Exam`)

- Displays only questions and answers.
- Logs results to `FinalExam_1.txt`

### 9. `Subject`

Represents the subject an exam is associated with.

### 10. `Student` & Notification System

- Implements event-driven notifications when an exam starts.

## Usage

1. Run the application.
2. The user selects an exam type (Practice or Final Exam).
3. The system loads the appropriate exam and questions from `Questions.txt`.
4. If `Practice Exam`, correct answers are displayed after completion.
5. If `Final Exam`, only questions and answer choices are displayed.
6. Exam results are logged and displayed.




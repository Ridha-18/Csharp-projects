import React, { useEffect, useState } from "react";
import { getAllCourses } from "../services/courseService";
import { getAllStudents } from "../services/studentService";
import "../App.css";

export default function Courses() {
  const [courses, setCourses] = useState([]);
  const [students, setStudents] = useState([]);

  useEffect(() => {
    getAllCourses()
      .then(data => setCourses(data))
    .catch(err => console.error(err));

    getAllStudents()
      .then(data => setStudents(data)) 
      .catch(err => console.error(err));
  }, []);


  // Helper function to count students in a course
  const getStudentCount = (courseId) => {
    return students.filter((s) => s.courseId === courseId).length;
  };

  return (
    <div>
      <h2>All Courses</h2>
      <table border="1" cellPadding="10">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Description</th>
            <th>Total Students</th>
          </tr>
        </thead>
        <tbody>
          {courses.map(course => (
            <tr key={course.id}>
              <td>{course.id}</td>
              <td>{course.name}</td>
              <td>{course.description}</td>
              <td>{getStudentCount(course.id)}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

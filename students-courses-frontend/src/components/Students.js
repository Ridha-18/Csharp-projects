import React, { useEffect, useState } from "react";
import { getAllStudents, addStudent, updateStudent, deleteStudent } from "../services/studentService";
import "../App.css";

export default function Students() {
  const [students, setStudents] = useState([]);
  const [name, setName] = useState("");
  const [courseId, setCourseId] = useState("");
  const [editingId, setEditingId] = useState(null);

  useEffect(() => {
    fetchStudents();
  }, []);

  const fetchStudents = async () => {
    const data = await getAllStudents();
    setStudents(data);
  };

  const handleAddOrUpdate = async () => {
  try {
    if (editingId) {
      await updateStudent({ id: editingId, name, courseId: parseInt(courseId) });
      setEditingId(null);
    } else {
      await addStudent({ name, courseId: parseInt(courseId) });
    }
    setName("");
    setCourseId("");
    await fetchStudents(); 
  } catch (error) {
    alert(error.message);
  }
};

  const handleEdit = (student) => {
    setEditingId(student.id);
    setName(student.name);
    setCourseId(student.courseId);
  };

  const handleDelete = async (id) => {
    await deleteStudent(id);
    fetchStudents();
  };

  return (
    <div>
      <h2>All Students</h2>

      {/* Add/Edit Form */}
      <input placeholder="Name" value={name} onChange={(e) => setName(e.target.value)} />
      <input placeholder="Course ID" value={courseId} onChange={(e) => setCourseId(e.target.value)} />
      <button onClick={handleAddOrUpdate}>{editingId ? "Update" : "Add"}</button>

      <table border="1" cellPadding="10" style={{ marginTop: "20px" }}>
        <thead>
          <tr>
            
            <th>Name</th>
            <th>Course ID</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {students.map((student) => (
            <tr key={student.id}>
           
              <td>{student.name}</td>
              <td>{student.courseId}</td>
              <td>
                <button onClick={() => handleEdit(student)}>Edit</button>
                <button onClick={() => handleDelete(student.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

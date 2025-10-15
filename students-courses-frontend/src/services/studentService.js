const STUDENTS_API = "https://localhost:7105/api/Students";

// GET all students
export async function getAllStudents() {
  const response = await fetch(STUDENTS_API);
  if (!response.ok) {
    const errorText = await response.text();
    throw new Error(errorText || "Failed to fetch students");
  }
  return await response.json();
}



// POST new student
export async function addStudent(student) {
  const response = await fetch(STUDENTS_API, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(student),
  });
   if (!response.ok) {
    const errorText = await response.text();
    throw new Error(errorText || "Failed to add student");
  }

  return await response.json();
}


// PUT (update) student
export async function updateStudent(student) {
  const response = await fetch(`${STUDENTS_API}/${student.id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(student),
  });

  if (!response.ok) {
    const errorText = await response.text();
    throw new Error(errorText || "Failed to update student");
  }

  return true;
}

// DELETE student
export async function deleteStudent(id) {
  const response = await fetch(`${STUDENTS_API}/${id}`, {
    method: "DELETE",
  });
   if (!response.ok) {
    const errorText = await response.text();
    throw new Error(errorText || "Failed to delete student");
  }

  return true;
}

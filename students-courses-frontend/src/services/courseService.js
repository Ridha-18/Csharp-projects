const COURSES_API = "https://localhost:7105/api/Courses";

export async function getAllCourses() {
  const response = await fetch(COURSES_API);
  if (!response.ok) throw new Error("Failed to fetch courses");
  return await response.json();
}

export async function addCourse(course) {
  const response = await fetch(COURSES_API, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(course)
  });
  return await response.json();
}

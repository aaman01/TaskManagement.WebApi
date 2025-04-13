# 📝 Task Management Web API

A simple RESTful API built with ASP.NET Core (.NET 6+) and Entity Framework Core (In-Memory) to manage tasks.

---

## 🚀 Setup & Run

### ✅ Prerequisites
  .NET 6 SDK or higher

### 📦 API Endpoints:
  
  ➕ Create Task
  POST /api/tasks
  Request Body:
  <pre>
  {
    "title": "Finish report",
    "description": "Complete the financial report",
    "dueDate": "2025-04-15T23:59:00",
    "isComplete": false
  }
  </pre>

  Response: 201 Created
  <pre> 
  {
    "id": 1,
    "title": "Finish report",
    "description": "Complete the financial report",
    "dueDate": "2025-04-15T23:59:00",
    "isCompleted": false
  }
   </pre>
  📖 Get All Tasks
  GET /api/tasks
  
  Response: 200 OK
  <pre>
  [
    {
      "id": 1,
      "title": "Finish report",
      "description": "Complete the financial report",
      "dueDate": "2025-04-15T23:59:00",
      "isCompleted": false
    }
  ]
  </pre>  
  📖 Get Task by ID
  GET /api/tasks/{id}
  
  Response: 200 OK or 404 Not Found

  ✏️ Update Task
  PUT /api/tasks/{id}
  
  Request Body:
  <pre>
  {
  "title": "Report",
  "description": "Financial report done",
  "dueDate": "2025-04-20T17:00:00",
  "isComplete": true
  }
  </pre>
  Response: 200 OK or 400 / 404 / 500

  ❌ Delete Task
  DELETE /api/tasks/{id}
  
  Response: 200 OK or 404 Not Found


⚠️ Known Limitations

  Uses In-Memory Database — data is lost on restart

  No authentication or user management

  No front-end UI included

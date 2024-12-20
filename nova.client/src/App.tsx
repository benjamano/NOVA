import { useEffect, useState } from 'react';  
import './App.css';  
import $ from 'jquery';

interface Task {  
    id: number;  
    title: string;  
    description: string;  
    status: string;  
    dueDate: string;  
}  
  
function App() {  
    const [tasks, setTasks] = useState<Task[]>();  
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [showNewTaskForm, setShowNewTaskForm] = useState<boolean>(false);
  
    useEffect(() => {  
        fetchTasks();  
    }, []);  

    const showNewTaskInputs = () => {
        $("#addNewTaskbtn").hide();
        setShowNewTaskForm(true);
    };

    const addNewTask = async () => {
        const newTask = {
            Title: (document.getElementById('taskTitle') as HTMLInputElement).value,
            Description: (document.getElementById('taskDesc') as HTMLInputElement).value,
            Status: (document.getElementById('taskStatus') as HTMLInputElement).value,
            DueDate: (document.getElementById('taskDueDate') as HTMLInputElement).value,
        };

        try {
            const response = await fetch('NovaAPI/AddNewTask', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newTask),
            });

            if (response.ok) {
                setShowNewTaskForm(false);
                fetchTasks();
                $("#addNewTaskbtn").show();
            } else {
                console.error('Failed to add new task');
            }
        } catch (error) {
            console.error('Error adding new task:', error);
        }
    };

    const fetchTasks = async () => {
        try {
            const response = await fetch('NovaAPI/GetAllTasks');
            if (response.ok) {
                const data = await response.json();
                setTasks(data);
            }
        } catch (error) {
            console.error('Error fetching tasks:', error);
        } finally {
            setIsLoading(false);
        }
    };
  
    const taskDataTable = isLoading ? (
        <p><em className="spinner-border spinner-border-sm" role="status" aria-hidden="true"></em></p>)
        :
        ( <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Status</th>
                    <th>Due Date</th>
                </tr>
            </thead>
            <tbody id="taskTableTBody">
                {tasks?.map((task) => (
                    <tr key={task.id}>
                        <td>{task.title}</td>
                        <td>{task.description}</td>
                        <td>{task.status}</td>
                        <td>{task.dueDate}</td>
                    </tr>
                ))}
                {showNewTaskForm && (
                    <tr id="newTaskForm">
                        <td><input id="taskTitle" type="text" placeholder="Title" /></td>
                        <td><input id="taskDesc" type="text" placeholder="Description" /></td>
                        <td><input id="taskStatus" type="text" placeholder="Status" /></td>
                        <td><input id="taskDueDate" type="date" placeholder="Due Date" /></td>
                        <td><button onClick={addNewTask}>Add Task</button></td>
                    </tr>
                )}
            </tbody>
        </table>
    );

    return (
        <div>
            <h1 id="tableLabel">Your Tasks</h1>
            {taskDataTable}
            <button id="addNewTaskbtn" className="addNewTaskbtn" onClick={showNewTaskInputs}>+</button>
        </div>
    );
}  
  
export default App;
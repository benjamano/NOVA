import { useEffect, useState } from 'react';
import './App.css';

interface Task {
    id: number;
    title: string;
    description: string;
    status: string;
    dueDate: string;
}

function App() {
    const [tasks, setTasks] = useState<Task[]>();

    useEffect(() => {
        getTasks();
    }, []);

    const contents = tasks === undefined
        // ? - This is what's shown when it is fetching the data from the server
        // : - After data has been fetched

        ? <p><em>Loading...</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Status</th>
                    <th>Due Date</th>
                </tr>
            </thead>
            <tbody>
                {tasks.map(Task =>
                    <tr key={Task.id}>
                        <td>{Task.title}</td>
                        <td>{Task.description}</td>
                        <td>{Task.status}</td>
                        <td>{Task.dueDate}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Your Tasks</h1>
            {contents}
        </div>
    );

    async function getTasks() {
        const response = await fetch("NovaAPI/GetAllTasks");
        if (response.ok) {
            const data = await response.json();
            setTasks(data);
        }
    }
}

export default App;
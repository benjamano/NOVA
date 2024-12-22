import { useEffect, useState } from 'react';
import './App.css';
import $ from 'jquery';
import { DragDropContext, Droppable, Draggable } from 'react-beautiful-dnd';

interface Task {
    taskId: number;
    title: string;
    description: string;
    status: string;
    dueDate: string;
}

function App() {
    const [tasks, setTasks] = useState<Task[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [showNewTaskForm, setShowNewTaskForm] = useState<boolean>(false);

    useEffect(() => {
        fetchTasks();
    }, []);

    const showNewTaskInputs = () => {
        $("#addNewTaskbtn").hide();
        setShowNewTaskForm(true);
    };

    const renderStatus = (status: string) => {
        var colour = "#80808042";

        switch (status) {
            case "Not Started":
                break;
            case "Blocked":
                break;
            case "In Progress":
                break;
            case "Complete":
                break;
        }

        return (
            <p style={{ padding: "0.3rem 0.8rem", borderRadius: "0.5rem", backgroundColor:colour }}>{status}</p>  
        );
    }

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

    const onDragEnd = async (result: any) => {
        const { source, destination } = result;

        if (!destination) return;

        if (source.droppableId === destination.droppableId && source.index === destination.index) return;

        const newTask = {
            TaskId: source.index,
            NewStatus: destination.droppableId,
        };

        try {
            const response = await fetch('NovaAPI/ChangeTaskStatus', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newTask),
            });

            if (response.ok) {
                fetchTasks();
            } else {
                console.error('Failed to add new task');
            }
        } catch (error) {
            console.error('Error adding new task:', error);
        }
    };

    const renderTasks = (status: string) => (
        tasks
            .filter((task) => task?.status === status)
            .map((task, index) => (
                <Draggable key={task?.taskId?.toString()} draggableId={task?.taskId?.toString()} index={task?.taskId}>
                    {(provided) => (
                        <div
                            ref={provided.innerRef}
                            {...provided.draggableProps}
                            {...provided.dragHandleProps}
                            className="task">
                            <p>{task.title}</p>
                            <p>{task.description}</p>
                            {/*<p>{renderStatus(task.status)}</p>*/}
                            <p>{task.dueDate}</p>
                        </div>
                    )}
                </Draggable>
            ))
    );

    const DataBoardHeaders = (
        <DragDropContext onDragEnd={onDragEnd}>
            <div className="card">
                <div className="card-body">
                    <div className="row">
                        {['Not Started', 'Blocked', 'In Progress', 'Complete'].map((status, index) => (
                            <div className="col-3" key={index}>
                                <div className="taskStatusContainer">
                                    <h3>{status}</h3>
                                    <Droppable droppableId={status}>
                                        {(provided) => (
                                            <div
                                                ref={provided.innerRef}
                                                {...provided.droppableProps}
                                                className="taskContainer"
                                                id={index.toString()}>
                                                {renderTasks(status)}
                                                {provided.placeholder}
                                            </div>
                                        )}
                                    </Droppable>
                                    <button
                                        id="addNewTaskbtn"
                                        className="addNewTaskbtn"
                                        onClick={showNewTaskInputs}>
                                        +
                                    </button>
                                </div>
                            </div>
                        ))}
                    </div>
                </div>
            </div>
        </DragDropContext>
    );

    return (
        <div className="w-100">
            {isLoading ? <p>Loading...</p> : DataBoardHeaders}
        </div>
    );
}

export default App;

import '../../assets/styles/TaskVisualisation.css'
import refresh from '../../assets/icons/refresh.svg'

function TaskVisualisation() {
    return (
        <div className='task-visualisation'>
            <div className='task-visualisation-header'>
                <div>
                    <h4>Task Visualisation</h4>
                    <p>Visualize tasks as interconnected circles</p>
                </div>
                <div>
                    <button>
                        <img src={refresh} />
                    </button>
                </div>
            </div>
            <div className='task-visualisation-content'>
                uisdygdsyuagdia
            </div>
        </div>
    )
}

export default TaskVisualisation;
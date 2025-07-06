import '../../assets/styles/TaskVisualisation.css'
import refresh from '../../assets/icons/refresh.svg'
import { getRandomPosition, getRandomColor } from '../../utils/taskvisualizerhelper'

const users = [
    { name: "Pleasure", tasks: 5 },
    { name: "dsad", tasks: 7 },
    { name: "Cate", tasks: 5 },
    { name: "dsad", tasks: 1 },
];

function TaskVisualisation() {
    const positions = users.map(() => getRandomPosition());

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
            <div className="task-visualisation-content" style={{ position: "relative" }}>
                <svg className="task-visualisation-lines" style={{ position: "absolute", width: "90%", height: "90%" }}>
                    {
                        positions.flatMap((posA, i) =>
                            positions.slice(i + 1).map((posB, j) => (
                                <line
                                    key={`line-${i}-${i + 1 + j}`}
                                    x1={posA.x}
                                    y1={posA.y}
                                    x2={posB.x}
                                    y2={posB.y}
                                    stroke={getRandomColor()}
                                    strokeWidth="1"
                                />
                            ))
                        )
                    }
                </svg>

                {
                    users.map((user, index) => {
                        const pos = positions[index];
                        const size = 30 + user.tasks * 7;

                        return (
                            <div
                                key={user.name}
                                className="task-visualizer-circle"
                                style={{
                                    position: "absolute",
                                    left: pos.x - size / 2,
                                    top: pos.y - size / 2,
                                    width: size,
                                    height: size,
                                    borderRadius: "50%",
                                    backgroundColor: getRandomColor(),
                                    display: "flex",
                                    alignItems: "center",
                                    justifyContent: "center",
                                    color: "white",
                                    fontSize: 12,
                                    boxShadow: "0 0 8px rgba(0,0,0,0.2)",
                                    zIndex: 1
                                }}
                            >
                                {user.name}
                            </div>
                        );
                    })
                }
            </div>
        </div>
    )
}

export default TaskVisualisation;
import './TaskInformation.css';
import logo from '../../assets/icons/calendar.svg'

function TaskInformation(props) {
  return (
    <div className="task-information-box">
      <div className="task-information-box-header">
        <h4>{props.title}</h4>
        <img src={logo} />
      </div>
      <h3>89</h3>
      <p>Task Information</p>
    </div>
  );
}

export default TaskInformation;
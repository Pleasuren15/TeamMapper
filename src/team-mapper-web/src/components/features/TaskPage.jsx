import '../../assets/styles/TaskPage.css';
import dashboard from '../../assets/icons/dashboard.svg';
import calendar from '../../assets/icons/calendar.svg';
import team from '../../assets/icons/team.svg';
import reports from '../../assets/icons/reports.svg';
import task from '../../assets/icons/task.svg';
import TaskInformation from '../common/TaskInformation';
import TaskVisualisation from './TaskVisualisation';
import TeamView from './TeamView';
import { useState } from 'react';
import logo from '../../assets/icons/logo.svg';
import alert from '../../assets/icons/alert.svg';
import question from '../../assets/icons/question.svg';

function TaskPage() {
  const [isTeamViewVisible, setIsTeamViewVisible] = useState(true);

  return (
    <div className="task-content">
      <div className="task-content-navigation">
        <h3>
          <img src={logo} /> &nbsp; TeamMapper
        </h3>
        <ul>
          <li className="task-content-navigation-item">
            <img src={dashboard} alt="Dashboard Icon" />
            <a href="#dashboard">Dashboard</a>
          </li>
          <li className="task-content-navigation-item">
            <img src={task} alt="Task Icon" />
            <a href="#calender">Tasks</a>
          </li>
          <li className="task-content-navigation-item">
            <img src={team} alt="Team Icon" />
            <a href="#team">Team</a>
          </li>
          <li className="task-content-navigation-item">
            <img src={calendar} alt="Calendar Icon" />
            <a href="#calender">Calendar</a>
          </li>
          <li className="task-content-navigation-item">
            <img src={reports} alt="Reports Icon" />
            <a href="#reports">Reports</a>
          </li>
        </ul>
      </div>

      <div className="task-content-visualisation">
        <h2>Task Visualisation</h2>
        <p>Visualise and manage your tasks with an interactive circle-based visualisation</p>
        <div className="task-information-container">
          <TaskInformation title="Total Tasks" number={8} description="5 ongoing, 3 Complete" />
          <TaskInformation title="High Priority" number={4} description="50% of all tasks" />
          <TaskInformation title="Team Members" number={5} description="Working on 8 tasks" />
          <TaskInformation title="Categories" number={15} description="Across all projects" />
        </div>
        <div className="task-content-visualisation-content">
          <div className="task-content-visualisation-content-header">
            <button onClick={() => setIsTeamViewVisible(true)}>Visualisation</button>
            <button onClick={() => setIsTeamViewVisible(false)}>Team View</button>
          </div>
          <div>
            {isTeamViewVisible && (
              <TaskVisualisation />
            )
            }
            {!isTeamViewVisible && (
              <TeamView />
            )}
          </div>
        </div>
      </div>
    </div>
  );
}

export default TaskPage;
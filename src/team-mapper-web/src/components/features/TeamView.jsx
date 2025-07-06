import '../../assets/styles/TeamView.css'
import TeamMemberCard from '../common/TeamMemberCard';

const tasks = [
  {
    "description": "Set up GitHub Actions for CI/CD pipeline",
    "date": "2025-07-06T11:49:00Z"
  },
  {
    "description": "Configure Redis distributed locking for booking system",
    "date": "2025-07-05T14:22:00Z"
  },
  {
    "description": "Dockerize SQL Server for Linux containers on Windows agents",
    "date": "2025-07-03T09:15:00Z"
  },
  {
    "description": "Design Fortnite-themed info dashboard with stylized UI",
    "date": "2025-07-02T17:30:00Z"
  },
  {
    "description": "Debug Dapper stored procedure with ExecuteScalarAsync",
    "date": "2025-06-30T08:05:00Z"
  }
]

function TeamView() {
  return (
    <div className='team-view'>
      <TeamMemberCard name="Pleasure Ndhlovu" tasks={[tasks[0], tasks[2], tasks[3]]} gender="male" />
      <TeamMemberCard name="Pleasure Ndhlovu" tasks={[]} gender="male" />
      <TeamMemberCard name="Pleasure Ndhlovu" tasks={[tasks[2], tasks[4], tasks[0], , tasks[0]]} gender="female" />
    </div>
  )
}

export default TeamView;
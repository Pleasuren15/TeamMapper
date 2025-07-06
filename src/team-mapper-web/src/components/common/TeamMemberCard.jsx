import './TeamMemberCard.css'
import male from '../../assets/icons/male.svg'
import female from '../../assets/icons/female.svg'

function TeamMemberCard(props) {
    return (
        <div className='team-member-card'>
            <div className="team-member-card-header">
                <div className='team-member-card-header-details'>
                    <div>
                        {props.gender == "male" && (
                            <img src={male} alt="male image" />
                        )}
                        {props.gender == "female" && (
                            <img src={female} alt="female image" />
                        )}
                    </div>
                    <div>
                        <h4>{props.name}</h4>
                        <p>{props.tasks.length} Tasks</p>
                    </div>
                </div>
                <h5 className='team-member-card-ongoing-badge'>1 ongoing</h5>
            </div>
            {
                props.tasks.map((item, _) => (
                    <div className="team-member-card-header-items">
                        <p>{item.description}</p>
                        <p>{new Date(item.date).toLocaleDateString()}</p>
                    </div>
                ))
            }
        </div>
    )
}

export default TeamMemberCard;
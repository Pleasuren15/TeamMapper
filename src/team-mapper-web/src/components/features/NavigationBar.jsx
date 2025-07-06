import logo from '../../assets/icons/logo.svg';
import alert from '../../assets/icons/alert.svg';
import question from '../../assets/icons/question.svg';
import '../../assets/styles/NavigationBar.css';

function NavigationBar() {
    return (
        <div className='navigation-bar'>
            <div className='navigation-bar-logo'>
                <h3>
                    <img src={logo}  /> TeamMapper
                </h3>
            </div>
            <div className='navigation-bar-notifications'>
                <h2>
                    <img src={alert}  />
                    <img src={question}  />
                </h2>
            </div>
        </div>
    )
}

export default NavigationBar;
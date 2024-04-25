import React from "react";
import "../scss/pages/profile/_profile.scss";
import catImage from "../assets/photos/cat-img2.png";
import logo from "../assets/icons/adopt_me_white.png";
const Profile = () => {
  return (
    <div className="profile">
      <div className="leftSide">
        <div className="img">
          <img src={catImage} alt="cat" />
        </div>
        <div className="logo">
          <img src={logo} alt="adopt-me-white" />
        </div>
      </div>
      <div className="rightSide">
        <div className="signUp">
          <p>You don’t have an account? Sign up</p>
        </div>
        <div className="signIn">
          <h2>Log in to Adopt Me</h2>
          <form action="">
            <div className="inputs">
              <div className="input">
                <label htmlFor="email">Email</label>
                <input type="text" id="email" />
              </div>
              <div className="input">
                <label htmlFor="password">Password</label>
                <input type="text" id="password" placeholder="6+ character" />
              </div>
              <div className="checkbox">
                <input type="checkbox" />
                <p>
                  Creating an account means you’re okay with our Terms of
                  Service, Privacy Policy, and our default Notification
                  Settings.
                </p>
              </div>
              <button>Sign In</button>
            </div>
            <p className="protect">
              This site is protected by reCAPTCHA and the Google Privacy Policy
              and Terms of Service apply.
            </p>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Profile;

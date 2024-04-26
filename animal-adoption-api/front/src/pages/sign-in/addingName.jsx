import { React, useRef, useState, useEffect } from "react";
import { Link } from "react-router-dom";
import axios from "axios";
import "../../scss/pages/sign-in/_addingName.scss";

const addingName = () => {
  const [nickName, setNickName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [number, setNumber] = useState("");

  const handleNickNameChange = (value) => {
    setNickName(value);
  };
  const handlePasswordChange = (value) => {
    setPassword(value);
  };
  const handleConfirmPasswordChange = (value) => {
    setConfirmPassword(value);
  };

  const handleEmailChange = (value) => {
    setEmail(value);
  };
  const handleNumberChange = (value) => {
    setNumber(value);
  };

  const handleSave = () => {
    const data = {
      NickName: nickName,
      Email: email,
      Password: password,
      PhoneNumber: number,
      ConfirmPassword: confirmPassword,
    };

    const url = "http://localhost:5078/api/v1/[controller]/register-user";
    axios
      .post(url, data)
      .then((result) => {
        alert(result.data);
      })
      .catch((error) => {
        alert(error);
      });
  };

  return (
    <div className="addingName">
      <div className="top_informations">
        <h1>Welcome to Guest Pet</h1>
        <p>
          Whether you need to report a lost or found pet or want to register
          your pet in case they go missing later - you’re in the right place.
        </p>
      </div>
      <div className="form">
        <form action="">
          <div className="inputs">
            <div className="inputs">
              <div className="input">
                <input
                  type="text"
                  id="nickname"
                  placeholder="Nick Name"
                  onChange={(e) => handleNickNameChange(e.target.value)}
                />
              </div>

              <div className="input">
                <input
                  type="email"
                  id="email"
                  placeholder="Email"
                  onChange={(e) => handleEmailChange(e.target.value)}
                />
              </div>
              <div className="input">
                <input
                  type="password"
                  id="password"
                  placeholder="Password"
                  onChange={(e) => handlePasswordChange(e.target.value)}
                />
              </div>
              <div className="input">
                <input
                  type="password"
                  id="confirm-password"
                  placeholder="Confirm Password"
                  onChange={(e) => handleConfirmPasswordChange(e.target.value)}
                />
              </div>
              <div className="input">
                <input
                  type="number"
                  id="number"
                  placeholder="Number"
                  onChange={(e) => handleNumberChange(e.target.value)}
                />
              </div>
            </div>
          </div>
          <div className="btn">
            <Link to="/">
              <button onClick={() => handleSave()}>Continue</button>
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
};

export default addingName;

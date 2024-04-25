import React, { useState } from "react";
import "../../scss/pages/sign-in/_addingName.scss";
import axios from "axios";

const addingName = () => {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");

  const handleFirstNameChange = (value) => {
    setFirstName(value);
  };
  const handleLastNameChange = (value) => {
    setLastName(value);
  };
  const handleSave = () => {
    const data = {
      Name: firstName,
      Surname: lastName,
    };
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
            <div className="input">
              <input
                type="text"
                id="firstName"
                placeholder="First Name"
                onChange={(e) => handleFirstNameChange(e.target.value)}
              />
            </div>
            <div className="input">
              <input
                type="text"
                id="lastName"
                placeholder="Last Name"
                onChange={(e) => handleLastNameChange(e.target.value)}
              />
            </div>
          </div>
          <div className="btn">
            <button onClick={() => handleSave()}>Continue</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default addingName;

import React from "react";
import { Link } from "react-router-dom";

const addEmail = () => {
  return (
    <div className="addingName">
      <div className="top_informations">
        <h1>What is your email?</h1>
        <p>
          We’ll only use your email to keep in touch about the pet you register.
        </p>
      </div>
      <div className="form">
        <form action="">
          <div className="inputs">
            <div className="input">
              <input type="email" id="email" placeholder="Email" />
            </div>
          </div>
          <div className="btn">
            <Link to="/add-password">
              <button>Continue</button>
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
};

export default addEmail;

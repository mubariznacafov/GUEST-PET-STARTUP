import React from "react";
import { Link } from "react-router-dom";

const addEmail = () => {
  const [email, setEmail] = useState("");

  const handleEmailChange = (value) => {
    setEmail(value);
  };
  
  const handleSave = () => {
    const data = {
      Email:email
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
        <h1>What is your email?</h1>
        <p>
          We’ll only use your email to keep in touch about the pet you register.
        </p>
      </div>
      <div className="form">
        <form action="">
          <div className="inputs">
            <div className="input">
              <input type="email" id="email" placeholder="Email" onChange={(e) => handleEmailChange(e.target.value)} />
            </div>
          </div>
          <div className="btn">
            <Link to="/add-password">
              <button onClick={() => handleSave()}>Continue</button>
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
};

export default addEmail;

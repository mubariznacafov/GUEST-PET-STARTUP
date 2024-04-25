import React from "react";
import { Link } from "react-router-dom";

const addPassword = () => {
  const [password, setPassword] = useState("");

  const handlePasswordChange = (value) => {
    setPassword(value);
  };

  const handleSave = () => {
    const data = {
      Passord: password,
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
        <h1>Create Password</h1>
      </div>
      <div className="form">
        <form action="">
          <div className="inputs">
            <div className="input">
              <input
                type="password"
                id="email"
                placeholder="Password"
                onChange={(e) => handlePasswordChange(e.target.value)}
              />
            </div>
          </div>
          <div className="btn">
            <Link to="/">
              <button onClick={() => handleSave()}>Submit</button>
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
};

export default addPassword;

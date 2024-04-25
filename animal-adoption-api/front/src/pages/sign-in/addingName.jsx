import { React, useRef, useState, useEffect } from "react";
import { Link } from "react-router-dom";
import axios from "axios";
import "../../scss/pages/sign-in/_addingName.scss";
// import {
//   faCheck,
//   faTimes,
//   faInfoCircle,
// } from "@fortawesome/free-solid-svg-icons";
// import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

// const UserName_REGEX = /^[A-z][A-z0-9-_]{3,23}$/;
// const UserSurname_REGEX = /^[A-z][A-z0-9-_]{3,23}$/;
// const REGISTER_URL = "/register";

// const addingName = () => {
  // const userRef = useRef();
  // const errRef = useRef();

  // const [userName, setUserName] = useState("");
  // const [validName, setValidName] = useState(false);
  // const [userNameFocus, setUserNameFocus] = useState(false);

  // const [userSurname, setUserSurname] = useState("");
  // const [validSurname, setValidSurname] = useState(false);
  // const [userSurnameFocus, setUserSurnameFocus] = useState(false);

  // const [errMsg, setErrMsg] = useState("");
  // const [success, setSuccess] = useState(false);

  // useEffect(() => {
  //   userRef.current.focus();
  // }, []);

  // useEffect(() => {
  //   setValidName(UserName_REGEX.test(userName));
  // }, [userName]);

  // useEffect(() => {
  //   setValidSurname(UserSurname_REGEX.test(userSurname));
  // }, [userName]);

  // const handleSubmit = async (e) => {
  //   e.preventDefault();
  //   // if button enabled with JS hack
  //   const v1 = USER_REGEX.test(user);
  //   const v2 = PWD_REGEX.test(pwd);
  //   if (!v1 || !v2) {
  //     setErrMsg("Invalid Entry");
  //     return;
  //   }
  //   try {
  //     const response = await axios.post(
  //       REGISTER_URL,
  //       JSON.stringify({ user, pwd }),
  //       {
  //         headers: { "Content-Type": "application/json" },
  //         withCredentials: true,
  //       }
  //     );
  //     console.log(response?.data);
  //     console.log(response?.accessToken);
  //     console.log(JSON.stringify(response));
  //     setSuccess(true);
  //     //clear state and controlled inputs
  //     //need value attrib on inputs for this
  //     setUserName("");
  //     setUserSurname("");
  //   } catch (err) {
  //     if (!err?.response) {
  //       setErrMsg("No Server Response");
  //     } else if (err.response?.status === 409) {
  //       setErrMsg("Username Taken");
  //     } else {
  //       setErrMsg("Registration Failed");
  //     }
  //     errRef.current.focus();
  //   }
  // };
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
            <div className="input">
              <input
                type="text"
                id="username"
                placeholder="First Name"
                onChange={(e) => handleLastNameChange(e.target.value)}
                // ref={userRef}
                // autoComplete="off"
                // onChange={(e) => setUserName(e.target.value)}
                // value={userName}
                // required
                // aria-invalid={validName ? "false" : "true"}
                // aria-describedby="uidnote"
                // onFocus={() => setUserNameFocus(true)}
                // onBlur={() => setUserNameFocus(false)}
              />
              {/* <p
                id="uidnote"
                className={
                  userNameFocus && userName && !validName
                    ? "instructions"
                    : "offscreen"
                }
              >
                <FontAwesomeIcon icon={faInfoCircle} />
                4 to 24 characters.
                <br />
                Must begin with a letter.
                <br />
                Letters, numbers, underscores, hyphens allowed.
              </p> */}
            </div>
            <div className="input">
              <input type="text" id="lastName" placeholder="Last Name"  onChange={(e) => handleLastNameChange(e.target.value)}/>
            </div>
          </div>
          <div className="btn">
            <Link to="/add-email">
              <button onClick={() => handleSave()}>Continue</button>
            </Link>
          </div>
        </form>
      </div>
    </div>
  );
};

export default addingName;

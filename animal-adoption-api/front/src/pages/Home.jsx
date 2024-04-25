import React from "react";
import { Link } from "react-router-dom";
import "../scss/pages/home/_home.scss";
import DogImg from "../assets/photos/dog_image_main.jpeg";
import catImage from "../assets/photos/process.png";
import process3 from "../assets/photos/process1.png";
import process2 from "../assets/photos/process2.png";
import process1 from "../assets/photos/process3.png";
import person3 from "../assets/photos/person3.png";
import person2 from "../assets/photos/person2.png";
import person1 from "../assets/photos/person1.png";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faInstagram,
  faLinkedin,
  faXTwitter,
} from "@fortawesome/free-brands-svg-icons";
import { faDog, faCat, faFishFins } from "@fortawesome/free-solid-svg-icons";
const Home = () => {
  return (
    <div className="home">
      <div
        className="topPage"
        style={{ backgroundImage: "url(" + DogImg + ")" }}
      >
        <div className="main_info">
          <h1>Guest Pet</h1>
          <h3>
            Everything for <h3 className="forColor">Pets</h3>
          </h3>
          <div className="buttons">
            <button>
              <FontAwesomeIcon icon={faDog} color={"#623ab1"} />
              Dogs
            </button>
            <button>
              {" "}
              <FontAwesomeIcon icon={faCat} color={"#623ab1"}/>
              Cats
            </button>
            <button>
              {" "}
              <FontAwesomeIcon icon={faFishFins} color={"#623ab1"} /> Others
            </button>
          </div>
        </div>
        <div className="down_info">
          <div className="social_medias">
            <Link to={"https://www.instagram.com/"} target={"_blank"}>
              <FontAwesomeIcon icon={faInstagram} />
            </Link>
            <Link to={"https://www.linkedin.com/"} target={"_blank"}>
              <FontAwesomeIcon icon={faLinkedin} />
            </Link>
            <Link to={"https://www.twitter.com/"} target={"_blank"}>
              <FontAwesomeIcon icon={faXTwitter} />
            </Link>
          </div>
          <div className="left_infos">
            <p className="adopt">Adopt a pet today and start caring for it.</p>
            <p className="best">The best services for you!</p>
          </div>
        </div>
      </div>
      {/* <div className="aboutUs">
        <div className="leftSide">
          <div className="img">
            <img src={GirlWithPets} alt="" />
          </div>
        </div>
        <div className="rightSide">
          <div className="info">
            <h4>ABOUT US</h4>
            <p>
              Guest Pet is a company that aims to make great pet environment
              around the world. Our main idea is inviting people to adopt pets
              for free. With Guest Pet you can provide all requirements of your
              pet. We just want to make the pets smile. Now, adopt a pet and
              take care of it!
            </p>
          </div>
        </div>
      </div> */}

      {/* <div className="services">
        <div className="topInfo">
          <h3>QUALITY SERVICES</h3>
          <h2>We Care About Pets </h2>
          <p>
            We have multiple services to offer you for providing your dear pet's
            daily and health requirements
          </p>
        </div>
        <div className="cards">
          <div className="card">
            <div className="img">
              <img src={icon1} alt="" />
            </div>
            <h4>Vaccination</h4>
          </div>
          <div className="card">
            <div className="img">
              <img src={icon1} alt="" />
            </div>
            <h4>Vaccination</h4>
          </div>
          <div className="card">
            <div className="img">
              <img src={icon2} alt="" />
            </div>
            <h4>Vaccination</h4>
          </div>
          <div className="card">
            <div className="img">
              <img src={icon3} alt="" />
            </div>
            <h4>Vaccination</h4>
          </div>
          <div className="card">
            <div className="img">
              <img src={icon4} alt="" />
            </div>
            <h4>Vaccination</h4>
          </div>
          <div className="card">
            <div className="img">
              <img src={icon5} alt="" />
            </div>
            <h4>Vaccination</h4>
          </div>
          <div className="card">
            <div className="img">
              <img src={icon6} alt="" />
            </div>
            <h4>Vaccination</h4>
          </div>
          <div className="card">
            <div className="img">
              <img src={icon6} alt="" />
            </div>
            <h4>Vaccination</h4>
          </div>
        </div>
      </div> */}

      <div className="process">
        <div className="top_info">
          <h1 className="work">HOW WE WORK</h1>
          <h1 className="petAdoption">Pet Adoption Process</h1>
          <p>
            Our program facilitates pet adoptions by connecting potential
            adopters with available pets through our app. Find one of potential
            pets, contact with adopter and take it to your home!
          </p>
        </div>
        <div className="cards">
          <div className="card">
            <div className="img">
              <img src={process1} />
            </div>
            <div className="bottom_info">
              <h3>1. Find Your Pet</h3>
              <p>Find your pet friend online for taking care of it</p>
            </div>
          </div>
          <div className="card">
            <div className="img">
              <img src={process2} />
            </div>
            <div className="bottom_info">
              <h3>2. Know Pet</h3>
              <p>Meet your pet firend more closely</p>
            </div>
          </div>
          <div className="card">
            <div className="img">
              <img src={process3} />
            </div>
            <div className="bottom_info">
              <h3>1. Take Pet Home</h3>
              <p>Take your pet to your home and spend time with it</p>
            </div>
          </div>
        </div>
      </div>
      <div
        className="adoptNow"
        style={{ backgroundImage: "url(" + catImage + ")" }}
      >
        <div className="info">
          <h1>Want a Pet for the Your Loved Ones? </h1>
          <button className="btn">Adopt Now</button>
        </div>
      </div>
      <div className="reviews">
        <div className="top_info">
          <h1 className="review">REVIEWS</h1>
          <h1 className="expressions">What people say</h1>
          <p>Let's read what people say about our services and facilities.</p>
        </div>
        <div className="cards">
          <div className="card">
            <div className="profile">
              <div className="img">
                <img src={person3} alt="man_with_pet" />
              </div>
              <div className="full_name">Farid Hasanov</div>
            </div>
            <div className="expression">
              <p>
                “My aging pet's care became effortless with the diverse
                offerings available. From nutritious pet foods to accessible vet
                services, the app ensured my pet's well-being with convenience
                at every step.”
              </p>
            </div>
          </div>
          <div className="card card2">
            <div className="profile">
              <div className="img">
                <img src={person2} alt="child_with_pet" />
              </div>
              <div className="full_name">Leyla Jafarova</div>
            </div>
            <div className="expression">
              <p>
                "Providing everything from premium pet foods to reliable vet
                consultations, it's been a game-changer for my pet's health and
                happiness. Highly recommend for all pet owners seeking
                convenience and quality.”
              </p>
            </div>
          </div>
          <div className="card">
            <div className="profile">
              <div className="img">
                <img src={person1} alt="woman_with_pet" />
              </div>
              <div className="full_name">Aysel Aliyeva</div>
            </div>
            <div className="expression">
              <p>
                “My senior cat's needs were met beyond expectations. From
                accessing quality pet foods to connecting with vets, the app
                ensured a seamless experience, making pet care a breeze.”
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home;

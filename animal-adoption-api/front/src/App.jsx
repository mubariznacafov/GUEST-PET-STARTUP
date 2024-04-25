import React, { useState } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom"; // Import useLocation
import Profile from "./pages/Profile";
import Home from "./pages/Home";
import Blog from "./pages/Blog";
import ZooShop from "./pages/ZooShop";
import Veterinary from "./pages/Veterinary";
import Navbar from "./pages/Navbar";
import Footer from "./pages/Footer";
import Favorites from "./pages/Favorites";
import AddingName from "./pages/sign-in/addingName";
import AddingEmail from "./pages/sign-in/addEmail";
import AddingPhoto from "./pages/sign-in/addPhoto";
import AddingPassword from "./pages/sign-in/addPassword";
import MaybeShowFooter from "./components/MaybeShowFooter";

function App() {
  return (
    <div>
      <Router>
        <Navbar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/veterinary" element={<Veterinary />} />
          <Route path="/blog" element={<Blog />} />
          <Route path="/zoo-shop" element={<ZooShop />} />
          <Route path="/profile" element={<Profile />} />
          <Route path="/favorites" element={<Favorites />} />
          <Route path="/add-name" element={<AddingName />} />
          <Route path="/add-email" element={<AddingEmail />} />
          <Route path="/add-photo" element={<AddingPhoto />} />
          <Route path="/add-password" element={<AddingPassword />} />
        </Routes>
        <MaybeShowFooter>
          <Footer />
        </MaybeShowFooter>
      </Router>
    </div>
  );
}

export default App;

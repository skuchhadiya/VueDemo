import * as axios from "axios";

import { API } from "./config";

// for time constraint i will assume all service working correctly so not adding test
const addUser = async function(user) {
  try {
    const response = await axios.post("api/User", user);
    const addedUser = user;
    addedUser.id = response.data;
    return addedUser;
  } catch (error) {
    console.error(error);
    return null;
  }
};

const getProducts = async function(terms) {
  try {
    const url = `${API}/Product?UserID=${terms.id}&PropertyValue=${
      terms.propertyValue
    }&DepositeAmount=${terms.mortgageAmount}`;
    const response = await axios.get(url);
    return response.data;
  } catch (error) {
    console.error(error);
    return [];
  }
};

export const dataService = {
  addUser,
  getProducts
};

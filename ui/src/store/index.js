import Vue from "vue";
import Vuex from "vuex";

import { dataService } from "../shared";
import {
  ADD_USER,
  GET_USER,
  GET_PRODUCTS,
  ADD_PRODUCTS,
  UPDATE_SEARCHTERMS
} from "./mutation-types";

Vue.use(Vuex);

const state = () => ({
  user: { id: 0, firstName: "", lastName: "", dob: null, email: "" },
  searchTerms: { id: 0, propertyValue: null, mortgageAmount: null },
  products: []
});

const mutations = {
  [ADD_USER](state, user) {
    state.user = user;
  },

  [GET_USER](state, user) {
    state.user = user;
  },

  [ADD_PRODUCTS](state, products) {
    state.products = products; // mutable addition
  },

  [GET_PRODUCTS](state, products) {
    state.products = products;
  },

  [UPDATE_SEARCHTERMS](state, terms) {
    state.searchTerms = terms;
  }
};

const actions = {
  // actions let us get to ({ state, getters, commit, dispatch }) {
  async addUserAction({ commit }, user) {
    const addedUser = await dataService.addUser(user);
    commit(ADD_USER, addedUser);
  },

  async getProductsAction({ commit }, terms) {
    const products = await dataService.getProducts(terms);
    commit(ADD_PRODUCTS, products);
    commit(UPDATE_SEARCHTERMS, terms);
  }
};

const getters = {
  // parameterized getters are not cached. so this is just a convenience to get the state.
  getHeroById: state => id => state.heroes.find(h => h.id === id),
  getVillainById: state => id => state.villains.find(v => v.id === id)
};

export default new Vuex.Store({
  strict: process.env.NODE_ENV !== "production",
  state,
  mutations,
  actions,
  getters
});

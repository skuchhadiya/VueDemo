import { mount, createLocalVue } from "@vue/test-utils";
import ProductList from "../../src/views/products-list.vue";

import Vuex from "vuex";

const localVue = createLocalVue();
localVue.use(Vuex);
describe("products-list.vue", () => {
  let mocks;
  beforeEach(() => {
    mocks = {
      $router: [],
      $store: {
        state: {
          user: {
            id: 1,
            firstName: "Sanjay",
            lastName: "xxx",
            dob: "2020-05-05",
            email: "xyx@xyx.com"
          },
          searchTerms: {
            id: 1,
            propertyValue: 100000,
            mortgageAmount: 10001
          },
          products: []
        }
      }
    };
  });

  it("should render products-list if there is no data with msg", () => {
    const wrapper = mount(ProductList, { mocks: mocks });
    const notFoundElement = wrapper.find("#notFound");

    expect(notFoundElement.element.id).toBe("notFound");
    expect(notFoundElement.text()).toBe("Products not found");
    expect(wrapper.vm.products).toEqual([]);
  });

  it("should not render not found message, if products exists in store", () => {
    const products = [
      {
        lender: "Bank A",
        interestRate: 2,
        mortgageType: 0,
        loanToValuePercentage: 90
      }
    ];
    mocks.$store.state.products = products;
    const wrapper = mount(ProductList, { mocks: mocks });
    const notFoundElement = wrapper.find("#notFound").exists();
    expect(wrapper.vm.products.length).toBe(1);
    expect(notFoundElement).toBeFalsy();
  });

  it("should render products, if products exists in store", () => {
    const products = [
      {
        lender: "Bank A",
        interestRate: 2,
        mortgageType: 0,
        loanToValuePercentage: 90
      },
      {
        lender: "Bank B",
        interestRate: 2,
        mortgageType: 0,
        loanToValuePercentage: 90
      }
    ];
    mocks.$store.state.products = products;
    const wrapper = mount(ProductList, { mocks: mocks });
    expect(wrapper.vm.products.length).toBe(2);
    expect(wrapper.vm.products).toBe(products);
  });
});

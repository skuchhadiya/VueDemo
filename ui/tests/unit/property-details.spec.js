import { mount, createLocalVue } from "@vue/test-utils";
import PropertyDetails from "../../src/views/property-details.vue";

import Vuex from "vuex";

const localVue = createLocalVue();
localVue.use(Vuex);

describe("property-details.vue", () => {
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
          searchTerms: { id: 0, propertyValue: null, mortgageAmount: null }
        },
        actions: {
          getProductsAction: jest.fn()
        }
      }
    };
  });

  it("should render property-details vue with default state", () => {
    const wrapper = mount(PropertyDetails, { mocks: mocks });

    expect(wrapper.find("p").text()).toBe("Sanjay");
    expect(wrapper.vm.searchTerms.propertyValue).toBe(null);
    expect(wrapper.vm.searchTerms.mortgageAmount).toBe(null);
  });

  it("should able to call method getProductsAction with PropertyDetails detils on Find Products", async () => {
    const wrapper = mount(PropertyDetails, { mocks: mocks });
    let spyAction = jest
      .spyOn(wrapper.vm, "getProductsAction")
      .mockReturnValue([]);

    const newSearchTerms = {
      id: 0,
      propertyValue: 100000,
      mortgageAmount: 15000
    };

    wrapper.vm.searchTerms = newSearchTerms;
    wrapper.vm.getProducts();
    expect(wrapper.vm.searchTerms.id).toBe(1);
    expect(spyAction).toHaveBeenLastCalledWith(wrapper.vm.searchTerms);
  });
});

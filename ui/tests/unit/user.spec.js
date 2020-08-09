import { mount, createLocalVue } from "@vue/test-utils";
import User from "../../src/views/user.vue";

import Vuex from "vuex";

const localVue = createLocalVue();
localVue.use(Vuex);
describe("user.vue", () => {
  let mocks;
  beforeEach(() => {
    mocks = {
      $router: [],
      $store: {
        state: {
          user: { id: 0, firstName: "", lastName: "", dob: null, email: "" }
        },
        actions: {
          addUserAction: jest.fn()
        }
      }
    };
  });

  it("should render user vue with default state", () => {
    const wrapper = mount(User, { mocks: mocks });
    expect(wrapper.find("p").text()).toBe("");
  });

  it("should render user vue with vuex state value", () => {
    mocks.$store.state.user.firstName = "Sanjay";
    const wrapper = mount(User, { mocks: mocks });
    expect(wrapper.find("p").text()).toBe("Sanjay");
  });

  it("should able to call method addUserAction with newUser detils on saveAndContinue", async () => {
    const wrapper = mount(User, { mocks: mocks });
    const newUsser = {
      id: 0,
      firstName: "abc",
      lastName: "Kuchhadiya",
      dob: "2020-05-05",
      email: "fdgad@dfasdf.com"
    };
    let spyAction = jest.spyOn(wrapper.vm, "addUserAction").mockReturnValue(1);

    wrapper.vm.user = newUsser;

    //this will grab button which fire saveAndContinue click event
    wrapper.find("button").trigger("click");

    expect(spyAction).toHaveBeenLastCalledWith(wrapper.vm.user);
  });
});

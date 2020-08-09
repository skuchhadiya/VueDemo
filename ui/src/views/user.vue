<template>
  <div>
    <div class="section content-title-group">
      <h2 class="title">User Details</h2>
      <div class="card">
        <header class="card-header">
          <p class="card-header-title">{{ user.firstName }}</p>
        </header>
        <div class="card-content">
          <div class="content" v-if="user">
            <div class="field">
              <label class="label" for="firstName">First name</label>
              <input class="input" name="firstName" v-model="user.firstName" />
            </div>
            <div class="field">
              <label class="label" for="lastName">Last name</label>
              <input class="input" name="lastName" v-model="user.lastName" />
            </div>
            <div class="field">
              <label class="label" for="dob">Date of birth</label>
              <input type="date" class="input" name="dob" v-model="user.dob" />
            </div>
            <div class="field">
              <label class="label" for="email">Email</label>
              <input
                type="email"
                class="input"
                name="email"
                v-model="user.email"
              />
            </div>
          </div>
        </div>
        <footer class="card-footer">
          <button class="link card-footer-item" @click="saveAndContinue()">
            <i class="fas fa-save"></i>
            <span>Save and Continue</span>
          </button>
        </footer>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from "vuex";

export default {
  name: "User",
  data() {
    return {
      user: { ...this.$store.state.user }
    };
  },
  computed: {
    getUser() {
      return this.$store.state.user;
    }
  },
  methods: {
    ...mapActions(["addUserAction"]),
    async saveAndContinue() {
      await this.addUserAction(this.user);
      this.$router.push({ name: "PropertyDetails" });
    }
  }
};
</script>

<template>
  <div>
    <div class="section content-title-group">
      <h2 class="title">Property details</h2>
      <div class="card">
        <header class="card-header">
          <p class="card-header-title">{{ user.firstName }}</p>
        </header>
        <div class="card-content">
          <div class="content">
            <div class="field">
              <label class="label" for="propertyValue">Property Value</label>
              <input
                type="number"
                class="input"
                name="propertyValue"
                v-model="searchTerms.propertyValue"
              />
            </div>
            <div class="field">
              <label class="label" for="mortgageAmount">Mortgage Amount</label>
              <input
                type="number"
                class="input"
                name="mortgageAmount"
                v-model="searchTerms.mortgageAmount"
              />
            </div>
          </div>
        </div>
        <footer class="card-footer">
          <button class="link card-footer-item cancel-button" @click="onBack()">
            <i class="fas fa-undo"></i>
            <span>Back</span>
          </button>
          <button class="link card-footer-item" @click="getProducts()">
            <i class="fas fa-search"></i>
            <span>Find Products</span>
          </button>
        </footer>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  name: 'PropertyDetails',

  data() {
    return {
      searchTerms: { ...this.$store.state.searchTerms },
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
  },
  methods: {
    ...mapActions(['getProductsAction']),
    onBack() {
      this.$router.push({ name: 'User' });
    },
    async getProducts() {
      this.searchTerms.id = this.user.id;
      await this.getProductsAction(this.searchTerms);
      this.$router.push({ name: 'ProductList' });
    },
  },
};
</script>

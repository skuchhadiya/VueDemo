<template>
  <div>
    <div class="section content-title-group">
      <h2 class="title">Product List</h2>
      <div class="card">
        <header class="card-header">
          <p class="card-header-title">{{ title }}</p>
        </header>
        <div class="card-content">
          <div class="content">
            <table>
              <thead>
                <tr>
                  <th>Lender</th>
                  <th>Interest Rate</th>
                  <th>Mortgage Type</th>
                  <th>LTV Percentage</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(product, index) in products" :key="index">
                  <td>{{ product.lender }}</td>
                  <td>{{ product.interestRate }}%</td>
                  <td>{{ getMortgageType(product.mortgageType) }}</td>
                  <td>{{ product.loanToValuePercentage }}%</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <footer class="card-footer">
          <button class="link card-footer-item cancel-button" @click="onBack()">
            <i class="fas fa-undo"></i>
            <span>Back</span>
          </button>
        </footer>
      </div>
    </div>
  </div>
</template>

<script>
export const mortgageType = [
  { Key: 'Variable', Value: 0 },
  { Key: 'Fixed', Value: 1 },
];
export default {
  name: 'ProductList',
  computed: {
    title() {
      return (
        this.user.firstName +
        '   Property Value :' +
        this.searchTerms.propertyValue +
        '   Mortgage Amount :' +
        this.searchTerms.mortgageAmount
      );
    },

    user() {
      return this.$store.state.user;
    },
    searchTerms() {
      return this.$store.state.searchTerms;
    },
    products() {
      return this.$store.state.products;
    },
  },

  methods: {
    onBack() {
      this.$router.push({ name: 'PropertyDetails' });
    },

    getMortgageType(val) {
      return mortgageType.find((x) => x.Value === val).Key;
    },
  },
};
</script>

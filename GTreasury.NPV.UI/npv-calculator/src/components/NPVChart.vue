<template>
    <div class="multipleValues">
        <label>Present Values:</label>
        <div class="cashInFlows">
            <div v-for="presentValue in netPresentValueResults.PresentValues">
                <p> {{ presentValue }} </p>
            </div>
        </div>
    </div>
    <div class = "singleValue">
        <label>Total Cash Inflow:</label>
        <p> {{ netPresentValueResults.TotalCashInflow }} </p>
    </div>
    <div class = "singleValue">
        <label>Net Present Value:</label>
        <p> {{ netPresentValueResults.NetPresentValue }} </p>
    </div>
</template>

<script>
import { reactive } from 'vue'

export default {
  name: 'NPVForm',
  props: {
    netPresentValueResults: {
        type: Object
    }
  },
  setup(){
      const form = reactive({
        lowerBoundDiscountRate: 0,
        upperBoundDiscountRate: 0,
        discountRateIncrement: 0,
        years: 0,
        initialInvestment: 0
      })
      let index = 0
      return { form }
  }
}
</script>

<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>

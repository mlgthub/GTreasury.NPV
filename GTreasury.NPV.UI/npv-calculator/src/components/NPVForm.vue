<template>
  <form @submit.prevent="handleSubmit">
    <label>Initial Investment:</label>
    <input v-model="form.initialInvestment" type="number" min="1" required>
    <label>Lower Bound Discount Rate:</label>
    <input v-model="form.lowerBoundDiscountPercentage" type="number" min="0" max="100" required>
    <label>Upper Bound Discount Rate:</label>
    <input v-model="form.upperBoundDiscountPercentage" type="number" min="0" max="100" required>
    <label>Discount Rate Increment:</label>
    <input v-model="form.incrementalPercentage" type="number" min="0" max="100" required>
    <label>Years:</label>
    <input v-model="form.years" type="number" min="1" required>
    <label>Predicted Cash Flows:</label>
    <div v-for="index in form.years" :key="index" class="years">
      <label>Year {{ index }}</label>
      <input v-model="form.annualCashFlows[index]" type="number" min="1" class="yearInput" required>
    </div>
    <button>Calculate Net Present Value</button>
  </form>
</template>

<script setup>
import { reactive, defineEmits } from 'vue'

const emits = defineEmits(['npvResult'])

const form = reactive({
  lowerBoundDiscountPercentage: 0,
  upperBoundDiscountPercentage: 0,
  incrementalPercentage: 0,
  years: 0,
  initialInvestment: 0,
  annualCashFlows: []
})

const handleSubmit = async () => {
  form.annualCashFlows = form.annualCashFlows.filter(Number);
  try {
    await fetch('https://localhost:7239/NetPresentValue', {
      method: 'POST',
      headers: {
        'Access-Control-Allow-Origin': '*',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(form)
    }).then(res => res.json())
      .then(data => emits('npvResult', data))
  } catch (err) {
    console.error(err);
  }
}
</script>

<style scoped>
  form {
    max-width: 480px;
    margin: 0 auto;
    text-align: left;
  }
  input, textarea {
    display: block;
    margin: 10px 0;
    width: 100%;
    box-sizing: border-box;
    padding: 10px;
    border: 1px solid #eee;
  }
  textarea {
    height: 160px;
  }
  .years {
    display: block;
    margin: 0 0 0 0;
    padding: 8px;
    border-radius: 5px;
    font-size: 10px;
  }
  .yearInput {
    display: inline-block;
    margin: 0 0 0 0;
    padding: 8px;
    font-size: 10px;
    text-align: right;
  }
</style>
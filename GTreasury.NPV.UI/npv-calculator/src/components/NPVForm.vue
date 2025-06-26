<template>
  <form @submit.prevent="handleSubmit">
    <label>Initial Investment:</label>
    <input v-model="form.initialInvestment" type="number" required>
    <label>Lower Bound Discount Rate:</label>
    <input v-model="form.lowerBoundDiscountPercentage" type="number" required>
    <label>Upper Bound Discount Rate:</label>
    <input v-model="form.upperBoundDiscountPercentage" type="number" required>
    <label>Discount Rate Increment:</label>
    <input v-model="form.incrementalPercentage" type="number" required>
    <label>Years:</label>
    <input v-model="form.years" type="number" required>
    <label>Predicted Cash Flows:</label>
    <div v-for="index in form.years" :key="index" class="years">
      <label>Year {{ index }}</label>
      <input v-model="form.annualCashFlows[index]" type="number" class="yearInput" required>
    </div>
    <button>Calculate Net Present Value</button>
  </form>
</template>

<script setup>
const emit = defineEmits(['npv-result'])
import { reactive, defineEmits } from 'vue'

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
        const res = await fetch('https://localhost:7239/NetPresentValue', {
          method: 'POST',
          headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(form)
        })
        if (!res) {
          console.error(res);
        }
        console.log('before emit')
        emit('npv-result', res)
        console.log('emitting here')
      } catch (err) {
        console.error(err);
      }
    }
</script>

<style>
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
  label {
    display: inline-block;
    margin-top: 30px;
    position: relative;
    font-size: 20px;
    color: white;
    margin-bottom: 10px;
  }
  label::before {
    content: "";
    display: block;
    width: 100%;
    height: 100%;
    background: #32b910;
    position: absolute;
    z-index: -1;
    padding-right: 40px;
    left: -30px;
    transform: rotateZ(-1.5deg);
  }
  button {
    display: block;
    margin-top: 30px;
    background: #ff8800;
    color: white;
    border: none;
    padding: 8px 16px;
    font-size: 18px
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
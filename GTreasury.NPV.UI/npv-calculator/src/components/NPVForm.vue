<template>
  <form @submit.prevent="handleSubmit">
    <label>Initial Investment:</label>
    <input v-model="form.initialInvestment" type="number" min="1" step=".01" required>
    <label>Lower Bound Discount Rate:</label>
    <input v-model="form.lowerBoundDiscountPercentage" type="number" min="0" max="100" step=".01" required>
    <label>Upper Bound Discount Rate:</label>
    <input v-model="form.upperBoundDiscountPercentage" type="number" min="0" max="100" step=".01" required>
    <label>Discount Rate Increment:</label>
    <input v-model="form.incrementalPercentage" type="number" min="0" max="100" step=".01" required>
    <label>Years:</label>
    <input v-model="form.years" type="number" min="1" required>
    <label v-if="form.years">Predicted Cash Flows:</label>
    <div class="yearContainer">
      <div v-for="index in form.years" :key="index" class="years">
        <label>Year {{ index }}</label>
        <input v-model="form.annualCashFlows[index-1]" type="number" min="1" class="yearInput" step=".01" required>
      </div>
    </div>
    <button>Calculate Net Present Value</button>
  </form>
</template>

<script setup>
import { reactive, defineEmits } from 'vue'
import npvRequestModel from '../schemas/npvRequestModel.js'
import constants from '../constants'

const emits = defineEmits(['npvResult'])
const { apiUrl } = constants;
const form = reactive(npvRequestModel)

const handleSubmit = async () => {
  try {
    await fetch(`${apiUrl}/NetPresentValue`, {
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

<style>
  .yearContainer {
    display: flex;
    flex-wrap: wrap;
    max-height: 300px;
    overflow-y: auto;
  }
  .years {
    margin: 0 0 0 0;
    padding: 8px;
    border-radius: 5px;
    font-size: 10px;
  }
  .yearInput {
    display: inline-block;
    text-align: right;
  }

  @media screen and (min-width: 901px) {
    input {
      margin: 10px 0;
      padding: 10px;
    }
    .years {
      flex: 1 1 calc(33.333% - 20px);
      /* padding: 8px;
      border-radius: 5px; */
    }
    .yearInput {
      /* padding: 8px;
      font-size: 14px; */
    }
  }
  
  @media screen and (max-width: 900px) {
    .years {
      flex: 1 1 calc(33.333% - 20px);
      /* padding: 8px;
      border-radius: 5px; */
    }
    .yearInput {
      /* padding: 8px;
      font-size: 13px; */
    }
    input {
      margin: 9px 0;
      padding: 9px;
    }
  }

  @media screen and (max-width: 440px) {
    .years {
      flex: 0 1 calc(48% - 20px);
      /* padding: 7px;
      border-radius: 4px; */
    }
    .yearInput {
      /* padding: 7px;
      font-size: 12px; */
    }
    input {
      margin: 6px 0;
      padding: 6px;
    }
  }

  @media screen and (max-width: 270px) {
    .years {
      flex: 0 1 auto;
    }
  }
  form {
    text-align: left;
  }
  input {
    width: 100%;
    box-sizing: border-box;
    border: 1px solid #eee;
  }
</style>
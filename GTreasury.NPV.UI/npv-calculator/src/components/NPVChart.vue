<template>
    <Line :data="netPresentValueResults.arrangedChartData" :options="options" />
    <div>
        <label>Total Cash Inflow:</label>
        <p> {{ netPresentValueResults.totalCashInflow }} </p>
    </div>
    <div>
        <label>Net Present Value:</label>
        <p> {{ netPresentValueResults.netPresentValue }} </p>
    </div>
</template>

<script setup>
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
} from 'chart.js'
import { defineProps } from 'vue'
import { Line } from 'vue-chartjs'

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
)

const props = defineProps({
    netPresentValueResults: {
        type: Object
    }
})

const options = {
    responsive: false
}

</script>

<style>
  svg-icon svg { width: 90px;background: khaki;cursor: pointer }
  svg-icon:hover path { stroke: black }
</style>

<template>
    <h1>NPV Calculator Dashboard</h1>
    <div class="dashboard">
        <NPVForm @npv-result="receiveNPVResultFromForm" id="npvForm"/>
        <NPVChart
            v-if="renderKey"
            :key="renderKey"
            @npv-result="receiveNPVResultFromForm"
            id="npvChart"
            :netPresentValueResults="chartResults"
        />
    </div>
</template>

<script setup>
import { nextTick, ref } from 'vue'
import NPVForm from '../components/NPVForm.vue'
import NPVChart from '../components/NPVChart.vue'

let chartResults
const renderKey = ref(0)

const receiveNPVResultFromForm = (data) => {
    chartResults = data
    chartResults.arrangedChartData = arrangeChartData(data.presentValues)
    forceRerender();
}

function arrangeChartData(presentValues) {
    const chartData = {
        labels: [],
        datasets: [
            {
                label: 'Present Value',
                backgroundColor: '#f87979',
                data: []
            }
        ]
    }
    chartData.datasets[0].data = presentValues
    for (let i = 1; i <= presentValues.length;) {
        chartData.labels.push(`Year ${i++}`)
    }
    return chartData
}

async function forceRerender() {
    await nextTick()
    console.log(chartResults.arrangedChartData)
    renderKey.value += 1;
}
</script>

<style>
    #npvForm {
        width: 30%;
        display: inline-block;
        margin-left: 5%;
        margin-right: 5%;
    }
    #npvChart {
        width: 45%;
        display: inline-block;
        margin-left: 5%;
        margin-right: 5%;
    }
  label {
    display: inline-block;
    margin-top: 20px;
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
    padding-right: 30px;
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
</style>
<template>
    <br/>
    <p class="headerText">NPV Calculator Dashboard</p>
    <div class="dashboard">
        <NPVForm @npv-result="receiveNPVResultFromForm" id="npvForm"/>
        <NPVApexChart
            v-if="renderKey"
            :key="renderKey"
            id="npvChart"
            :netPresentValueResults="chartResults"
        />
        <!-- <NPVChart
            v-if="renderKey"
            :key="renderKey"
            id="npvChart"
            :netPresentValueResults="chartResults"
        /> -->
    </div>
</template>

<script setup>
import { nextTick, ref } from 'vue'
import NPVForm from '../components/NPVForm.vue'
import NPVApexChart from '../components/NPVApexChart.vue'

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
    display: inline-block;
}
#npvChart {
    display: inline-block;
}

.headerText {
    display: block;
    margin-inline-start: 0px;
    margin-inline-end: 0px;
    font-weight: bold;
    unicode-bidi: isolate;
}
@media screen and (min-width: 901px) {
    .headerText {
        font-size: 2em;
        margin-block-start: 0.67em;
        margin-block-end: 0.67em;
    }
    .dashboard {
        padding: 15px;
    }
    #npvForm {
        width: 40%;
    }
    #npvChart {
        width: 50%;
    }
    label {
        margin-top: 15px;
        font-size: 20px;
        margin-bottom: 9px;
    }
    label::before {
        padding-right: 29px;
        left: -15px;
    }
    button {
        margin-top: 30px;
        padding: 8px 16px;
        font-size: 18px
    }
}
@media screen and (max-width: 900px) {
    .headerText {
        font-size: 1.5em;
        margin-block-start: 0.5em;
        margin-block-end: 0.5em;
    }
    .dashboard {
        display: flex;
        flex-direction: column-reverse;
        padding: 12px;
    }
    #npvForm {
        width: 100%;
    }
    #npvChart {
        width: 100%;
    }

    label {
        margin-top: 12px;
        font-size: 17px;
        margin-bottom: 6px;
    }
    label::before {
        padding-right: 25px;
        left: -11px;
    }
    button {
        margin-top: 22px;
        padding: 6px 12px;
        font-size: 16px
    }
}
@media screen and (max-width: 490px) {
    .headerText {
        font-size: 1.2em;
        margin-block-start: 0.4em;
        margin-block-end: 0.4em;
    }
    .dashboard {
        display: flex;
        flex-direction: column-reverse;
        padding: 9px;
    }
    #app img {
        width: 95%;
    }
    label {
        margin-top: 9px;
        font-size: 13px;
        margin-bottom: 4px;
    }
    label::before {
        z-index: -1;
        padding-right: 21px;
        left: -11px;
    }
    button {
        margin-top: 14px;
        padding: 4px 8px;
        font-size: 12px
    }
}

label {
    display: inline-block;
    position: relative;
    color: white;
}
label::before {
    content: "";
    display: block;
    width: 100%;
    height: 100%;
    background: #32b910;
    position: absolute;
    z-index: -1;
    /* transform: rotateZ(-1.5deg); */
}
button {
    display: block;
    background: #ff8800;
    color: white;
    border: none;
}
</style>
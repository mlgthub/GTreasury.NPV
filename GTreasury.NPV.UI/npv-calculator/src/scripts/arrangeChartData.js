
import apexNPVChartOptions from '../schemas/apexNPVChartOptions.js'
import apexNPVChartSeries from '../schemas/apexNPVChartSeries.js'
import constants from '../constants'

const optionsData = apexNPVChartOptions
const seriesData = apexNPVChartSeries
const { currencySymbol } = constants;
let chartResults

export async function prepareChartData(chartData) {
    chartResults = chartData
    await updateNPVTitle()
    await updateXAxisByYears()
    await updateChartSeries()
    return { optionsData, seriesData }
}

export async function updateNPVTitle () {
    optionsData.title.text = `Invested ${currencySymbol}${chartResults.initialInvestment}`
    if (chartResults.netPresentValue < 0) {
        const positiveValue = chartResults.netPresentValue * -1
        optionsData.title.text += ` with -${currencySymbol}${positiveValue} NPV`
    } else {
        optionsData.title.text += ` with ${currencySymbol}${chartResults.netPresentValue} NPV`
    }
}

export async function updateXAxisByYears () {
    const yearNow = new Date().getFullYear()
    optionsData.xaxis.categories = []
    for (let i = 1; i <= chartResults.presentValues.length; i++) {
        optionsData.xaxis.categories.push(yearNow + i)
    }
}

export async function updateChartSeries () {
    seriesData[0].data = []
    seriesData[1].data = []
    seriesData[2].data = []
    for (let i = 0; i < chartResults.presentValues.length; i++) {
        seriesData[0].data.push(chartResults.discountPercentages[i])
        seriesData[1].data.push(chartResults.annualCashFlows[i])
        seriesData[2].data.push(chartResults.presentValues[i])
    }
}
import { prepareChartData } from '../scripts/arrangeChartData.js'
import testChartData from '../tests/testChartData.js'

const result = await prepareChartData(testChartData)


test('Discount Percentages have been transferred correctly.', () => {
    for (let i = 0; i < testChartData.discountPercentages.length; i++)
        expect(result.seriesData[0].data[i]).toBe(testChartData.discountPercentages[i])
})

test('Annual Cashflows have been transferred correctly.', () => {
    for (let i = 0; i < testChartData.annualCashFlows.length; i++)
        expect(result.seriesData[1].data[i]).toBe(testChartData.annualCashFlows[i])
})

test('Present Values have been transferred correctly.', () => {
    for (let i = 0; i < testChartData.presentValues.length; i++)
        expect(result.seriesData[2].data[i]).toBe(testChartData.presentValues[i])
})

test('Last x-axis category must be x (this year + length of present values length) years ahead of this year', () => {
    expect(result.optionsData.xaxis.categories[result.optionsData.xaxis.categories.length-1])
        .toBe(new Date().getFullYear() + result.optionsData.xaxis.categories.length)
})

test('Positive NPV must not have a -/minus sign on the Title', () => {
  expect(result.optionsData.title.text).not.toContain('-')
})

test('Negative NPV must have a -/minus sign on the Title', () => {
    const chartDataWithHighInvestment = structuredClone(testChartData)
    chartDataWithHighInvestment.initialInvestment = 32000
    chartDataWithHighInvestment.netPresentValue = -1572.55
    prepareChartData(chartDataWithHighInvestment).then(d => {
        expect(d.optionsData.title.text).toContain('-')
    })
})

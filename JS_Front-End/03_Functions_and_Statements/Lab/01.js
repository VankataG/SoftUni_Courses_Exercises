function formatGrade(grade)
{
    let gradeInWords;
    if (grade < 3.00)
    {
         console.log('Fail (2)');
         return;
    } 
    else if (grade < 3.50) gradeInWords = 'Poor';
    else if (grade < 4.50) gradeInWords = 'Good';
    else if (grade < 5.50) gradeInWords = 'Very good';
    else if (grade <= 6.00) gradeInWords = 'Excellent';

    console.log(`${gradeInWords} (${grade.toFixed(2)})`);
}

formatGrade(3.33);
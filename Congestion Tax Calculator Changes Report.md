# Congestion Tax Calculator Changes Report

## This is a note to my junior colleague.


Hi, 
my name is Farhad. 

This document outlines the changes made to the Congestion Tax Calculator project and provides a structured path for improving code quality and maintainability.

---

#### Changes Made:

1. **Fixed Time Window Bug**:
   - Corrected the condition for toll fees between 15:00 and 16:59. The logic now correctly distinguishes between the different time ranges.

2. **Implemented Single Charge Rule**:
   - Introduced logic to ensure that only the highest toll fee is charged for vehicles passing through multiple toll stations within a 60-minute window.

3. **Added Maximum Daily Cap**:
   - Ensured the total daily tax per vehicle is capped at 60 SEK by introducing a cap check after all tolls for the day are calculated.

4. **Separation of Concerns**:
   - Refactored the project into distinct classes:
     - **`TollFeeCalculator`**: Handles toll fee calculation based on time.
     - **`TollFreeDateChecker`**: Manages logic for toll-free dates (weekends and holidays).
     - **`TollFreeVehicleChecker`**: Verifies if a vehicle is exempt from toll fees.

5. **Removed Hardcoded Values**:
   - Replaced hardcoded toll-free vehicles and dates with lists, allowing the program to be extended or modified easily in the future.

6. **Optimized Conditions and Reduced Redundancy**:
   - Simplified time-based conditions in `TollFeeCalculator`, reducing unnecessary checks and improving readability.

---

#### Additional Recommendations Implemented:

1. **Organized Folder Structure**:
   - Created separate folders for classes, enums, and test files to enhance project organization and clarity.
     - Example structure:
       ```
       - Solution/
         - netcore/
            - Contracts/
               - IVehicle.cs
               - Car.cs
               - Motorcycles.cs
               - VehicleTypes.cs
            - Helpers/
               - TollFeeCalculator.cs
               - TollFreeDateChecker.cs
               - TollFreeVehicleChecker.cs
            - CongestionTaxCalculator.cs
         - tests/
           - CongestionTaxCalculator.cs
       ```

2. **Naming Conventions**:
   - Applied PascalCase to all namespaces, classes, methods, and variables to maintain consistency with standard C# naming conventions.
   - Interfaces are recommended to start with letter I.
   - Ensured method names clearly indicate their purpose (e.g., `GetTollFee`, `IsTollFreeDate`).

3. **Enums for Vehicle Types**:
   - Introduced an **`enum`** for vehicles (`VehicleTypes`) to avoid the use of string comparisons, reducing the likelihood of spelling errors and making the code more type-safe.

4. **Unit Testing with MsTest**:
   - Recommended the use of **MsTest** for unit testing.
   - Provided tests to validate:
     - Correct fee calculations for various time windows.
     - Enforcement of the 60-minute rule and daily cap.
     - Correct identification of toll-free vehicles and dates.

---

This refactoring improves the clarity, maintainability, and robustness of the Congestion Tax Calculator. It ensures proper adherence to coding standards while addressing critical bugs and optimizing the architecture.

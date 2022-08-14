namespace Scaffolding.Handlebars.Tests
{
    public partial class HbsTypeScriptScaffoldingGeneratorTests
    {
        private static class ExpectedEntities
        {
            public const string CategoryClass =
                @"import { Product } from './Product';

/**
* A category of products
*/
export interface Category {
    categoryId: number;
    /**
    * The name of a category
    */
    categoryName: string;
    products: Product[];
}
";

            public const string ProductClass =
                @"import { Category } from './Category';

export interface Product {
    productId: number;
    productName: string;
    unitPrice: number;
    discontinued: boolean;
    rowVersion: any;
    categoryId: number;
    category: Category;
}
";

            public const string EmployeeClass =
                @"import { Territory } from './Territory';

export interface Employee {
    employeeId: number;
    lastName: string;
    firstName: string;
    birthDate: Date;
    hireDate: Date;
    city: string;
    country: string;
    territories: Territory[];
}
";

            public const string EmployeeTerritoryClass =
                @"
export interface EmployeeTerritory {
    employeeId: number;
    territoryId: string;
}
";

            public const string TerritoryClass =
                @"import { Employee } from './Employee';

export interface Territory {
    territoryId: string;
    territoryDescription: string;
    employees: Employee[];
}
";
        }
    }
}
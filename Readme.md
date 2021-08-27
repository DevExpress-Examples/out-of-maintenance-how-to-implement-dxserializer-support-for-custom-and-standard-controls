<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/163256301/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830485)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to implement DXSerializer support for custom and standard controls 
 
We use the **DXSerializer** class to save/restore the layout in most of our WPF controls - see [Saving and Restoring Layouts](https://docs.devexpress.com/WPF/7391/common-concepts/saving-and-restoring-layouts) for more information. This example demonstrates how to use the same class for your custom controls or even standard components.

To enable **DXSerializer** for a particular control, set the attached **DXSerializer.SerializationID** property for it.

The next step is to specify what properties should be saved and restored. For this, you can use either of the following approaches.
- Assign the **XtraSerializableProperty** attribute to the required property. Here is one more example where we used this approach - [How to serialize custom panels and their properties](https://github.com/DevExpress-Examples/how-to-serialize-custom-panels-and-their-properties-e2324). 
- Subscribe to **DXSerializer.CustomGetSerializablePropertiesEvent**. In this example, we did this using the built-in **DXSerializer.AddCustomGetSerializablePropertiesHandler** method. 

See also: 
<br/>
[How to use the DXSerializer class to control the layout serialization process of DevExpress controls](https://www.devexpress.com/Support/Center/Question/Details/T139804/how-to-use-the-dxserializer-class-to-control-the-layout-serialization-process-of)

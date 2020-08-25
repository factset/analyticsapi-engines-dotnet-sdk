import org.openapitools.codegen.*;
import org.openapitools.codegen.languages.*;
import org.openapitools.codegen.utils.ProcessUtils;

import java.io.File;

public class CustomCSharpNetCoreClientCodegen extends CSharpNetCoreClientCodegen {
    
    @Override
    public void processOpts() {
        super.processOpts();

        String packageFolder = sourceFolder + File.separator + packageName;
        supportingFiles.add(new SupportingFile("utility_api.mustache", packageFolder + File.separator + apiPackage, "UtilityApi.cs"));

        supportingFiles.add(new SupportingFile("utility_api_doc.mustache", apiDocPath, "UtilityApi.md"));

        supportingFiles.add(new SupportingFile("StachExtensions.mustache", packageFolder, "StachExtensions.cs"));
    }
}
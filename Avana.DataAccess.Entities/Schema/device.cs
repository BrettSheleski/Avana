using System;
using System.Collections.Generic;
using System.Text;

namespace Avana.DataAccess.Entities.Schema
{
    enum device
    {
        device_id,
        name,
        description,
        model_family_id,
        mac_address
    }

    enum model_family
    {
        model_family_id,
        name,
        is_active
    }
}
